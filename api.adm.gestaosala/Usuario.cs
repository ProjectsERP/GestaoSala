using System;

public class Usuario
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(50)]
    public string Login { get; set; }
    [Required]
    [MaxLength(100)]
    public string Senha { get; set; }
}

