namespace pop1kolokwium.ModelsDTOs;

public class PreservationProjectDTO
{
    public int ProjectId { get; set; }
    public string Objective { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; } 
    public List<ArtifactDTO> Artifacts { get; set; } = new List<ArtifactDTO>();
}