using System.ComponentModel.DataAnnotations;

namespace SaveMom.Contracts.Dtos.Antenatal
{
    public class PregnancySummaryDto
    {
        [Required]
        public DateTime? LastMenstruationDate { get; set; }

        [Required]
        public DateTime? ExpectedDeliveryDate { get; set; }

        [Required]
        public int Gravida { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public int PerTerm { get; set; }

        [Required]
        public int? LivingNo { get; set; }

        [Required]
        public PregnancyLoss? PregnancyLoss { get; set; }
    }

    public class PregnancyLoss
    {
        [Required]
        public int AbortionNo { get; set;}

        [Required]
        public int EctopicNo { get; set;}

        [Required]
        public int StillBirthNo { get; set;}
    }
}
