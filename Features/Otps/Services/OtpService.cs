using CiberCheck.Data;
using CiberCheck.Features.Otps.Entities;
using CiberCheck.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class OtpService : IOtpService
{
    private readonly ApplicationDbContext _db;
    private readonly string _jwtSecret;

    public OtpService(ApplicationDbContext db, IConfiguration config)
    {
        _db = db;
        _jwtSecret = config["Jwt:Secret"]; // Lee el secret desde appsettings.json
    }

    public async Task<Otp> GenerateOtpAsync(string email, string? ipAddress = null, string? deviceId = null)
    {
        var lastOtp = await _db.Otp
            .Where(o => o.Email == email)
            .OrderByDescending(o => o.FechaCreacion)
            .FirstOrDefaultAsync();

        if (lastOtp != null && (DateTime.UtcNow - lastOtp.FechaCreacion).TotalSeconds < 30)
            throw new InvalidOperationException("Espere 30 segundos antes de generar un nuevo código.");

        // Invalida OTPs anteriores
        var oldOtps = await _db.Otp.Where(o => o.Email == email && !o.Usado).ToListAsync();
        foreach (var otp in oldOtps) otp.Usado = true;

        var codigo = GenerateSecureOtp();

        var newOtp = new Otp
        {
            Email = email,
            Codigo = codigo,
            FechaCreacion = DateTime.UtcNow,
            FechaExpiracion = DateTime.UtcNow.AddMinutes(5),
            Usado = false
        };

        _db.Otp.Add(newOtp);
        await _db.SaveChangesAsync();

        // Solo para pruebas: mostrar OTP en consola
        Console.WriteLine($"OTP para {email}: {codigo}");

        return newOtp;
    }

    public async Task<string?> VerifyOtpAsync(string email, string codigo)
    {
        var otp = await _db.Otp
            .Where(o => o.Email == email && o.Codigo == codigo && !o.Usado && o.FechaExpiracion >= DateTime.UtcNow)
            .OrderByDescending(o => o.FechaCreacion)
            .FirstOrDefaultAsync();

        if (otp == null) return null;

        otp.Usado = true;
        await _db.SaveChangesAsync();

        return GenerateJwtToken(email);
    }

    public async Task<Otp?> GetLastOtpByEmailAsync(string email)
    {
        return await _db.Otp
            .Where(o => o.Email == email)
            .OrderByDescending(o => o.FechaCreacion)
            .FirstOrDefaultAsync();
    }

    private string GenerateSecureOtp()
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] bytes = new byte[4];
        rng.GetBytes(bytes);
        int value = BitConverter.ToInt32(bytes, 0) % 1000000;
        value = Math.Abs(value);
        return value.ToString("D6");
    }

    private string GenerateJwtToken(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }



}
