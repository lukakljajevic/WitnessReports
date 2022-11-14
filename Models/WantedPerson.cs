namespace WitnessReportsApi.Models
{
	public class WantedPerson
    {
        public string? Id { get; set; }
        public string? Uid { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IEnumerable<WantedImage>? Images { get; set; }
        public IEnumerable<WantedFile>? Files { get; set; }
        public string? WarningMessage { get; set; }
        public string? Remarks { get; set; }
        public string? Details { get; set; }
        public string? AdditionalInformation { get; set; }
        public string? Caution { get; set; }
        public string? RewardText { get; set; }
        public int? RewardMin { get; set; }
        public int? RewardMax { get; set; }
        public IEnumerable<string>? DatesOfBirthUsed { get; set; }
        public string? PlaceOfBirth { get; set; }
        public IEnumerable<string>? Locations { get; set; }
        public IEnumerable<string>? FieldOffices { get; set; }
        public IEnumerable<string>? LegalNames { get; set; }
        public string? Status { get; set; }
        public string? PersonClassification { get; set; }
        public string? Ncic { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public int? WeightMin { get; set; }
        public int? WeightMax { get; set; }
        public int? HeightMin { get; set; }
        public int? HeightMax { get; set; }
        public string? Eyes { get; set; }
        public string? Hair { get; set; }
        public string? Build { get; set; }
        public string? Sex { get; set; }
        public string? Race { get; set; }
        public string? Nationality { get; set; }
        public string? ScarsAndMarks { get; set; }
        public string? Complexion { get; set; }
        public IEnumerable<string>? Occupations { get; set; }
        public IEnumerable<string>? PossibleCountries { get; set; }
        public IEnumerable<string>? PossibleStates { get; set; }
        public string? Modified { get; set; }
        public string? Publication { get; set; }
        public string? Path { get; set; }
    }
}

