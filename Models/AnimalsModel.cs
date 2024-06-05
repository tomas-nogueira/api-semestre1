﻿namespace Api.Models
{
    public class AnimalsModel
    {
        public int AnimalsId { get; set; }

        public string AnimalNome { get; set; } = string.Empty;

        public string AnimalRaca { get; set; } = string.Empty;

        public string AnimalTipo { get; set; } = string.Empty;

        public string AnimalCor { get; set; } = string.Empty;

        public string AnimalSexo { get; set; } = string.Empty;

        public string AnimalObservacao { get; set; } = string.Empty;

        public string AnimalFoto { get; set; } = string.Empty;

        public DateTime AnimalDtDesaparecimento { get; set; }

        public DateTime AnimalDtEncontro { get; set; }

        public byte AnimalStatus { get; set; }

        public int UsuarioId { get; set; }

        public static implicit operator List<object>(AnimalsModel v)
        {
            throw new NotImplementedException();
        }
    }
}

