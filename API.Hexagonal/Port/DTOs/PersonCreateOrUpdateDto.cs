namespace API.Hexagonal.Port.DTOs
{
    public class PersonCreateOrUpdateDto
    {
        public required string Nome { get; set; }
        public required int Cidade_id { get; set; }
        public required string Confirm_password { get; set; }
        public required int Cooperativa_id { get; set; }
        public required string Cpf { get; set; }
        public required string Email { get; set; }
        public required int Estado_id { get; set; }
        public required int Idade { get; set; }
        public required string Password { get; set; }
        public required int Perfil_id { get; set; }
        public required int Regiao_id { get; set; }
        public required int Setor_id { get; set; }

    }
}