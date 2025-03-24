namespace WH.Application.Dtos.Auth
{
    public class LoginRefreshTokenDto
    {
        public string ?RefreshToken { get; set; }
        public string ?AccessToken { get; set; }
    }
}
