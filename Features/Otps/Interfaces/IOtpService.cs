using System.Threading.Tasks;
using CiberCheck.Features.Otps.Entities;

namespace CiberCheck.Interfaces
{
    public interface IOtpService
    {
        Task<Otp> GenerateOtpAsync(string email, string? ipAddress = null, string? deviceId = null);

        
        /// Verifica un OTP y retorna un JWT si es válido.
 
        Task<string?> VerifyOtpAsync(string email, string codigo);


        /// Obtiene el último OTP generado para un correo.
       
        Task<Otp?> GetLastOtpByEmailAsync(string email);
    }
}
