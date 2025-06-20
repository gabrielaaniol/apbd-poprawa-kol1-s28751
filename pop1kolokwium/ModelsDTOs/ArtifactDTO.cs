namespace pop1kolokwium.ModelsDTOs;

public class ArtifactDTO
{
    public int ArtifactId { get; set; }
    public string Name { get; set; }
    public DateTime OriginDate { get; set; }
    public List<InstitutionDTO> Institutions { get; set; } = new List<InstitutionDTO>();
}