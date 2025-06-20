namespace pop1kolokwium.ModelsDTOs;

public class ResponseDTO
{
    public List<PreservationProjectDTO> PreservationProjects { get; set; }
    public List<StaffDTO> Staffs { get; set; } = new List<StaffDTO>();
    public InstitutionDTO Institution { get; set; } = new InstitutionDTO();
}

