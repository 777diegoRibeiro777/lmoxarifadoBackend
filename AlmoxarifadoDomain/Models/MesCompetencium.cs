﻿namespace AlmoxarifadoDomain.NomeDaPasta
{
    public partial class MesCompetencium
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int? Aberto { get; set; }

        public virtual Ano AnoNavigation { get; set; } = null!;
    }
}
