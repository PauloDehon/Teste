namespace Data.Entities
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(int id, string nome, string password, string email, string role)
        {
            Id = id;
            Nome = nome;
            Password = password;
            Email = email;
            Role = role;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
