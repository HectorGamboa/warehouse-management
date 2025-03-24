using WH.Domain.Entities;

namespace WH.Application.Dtos.Auth
{
    public class LoginUserResponseDto
    {
      public  string ?AccessToken { get; set; }
      public  string ?RefreshToken { get; set; }
      public User ?User { get; set; }

    }
}
