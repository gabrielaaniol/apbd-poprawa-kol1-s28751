namespace pop1kolokwium.ModelsDTOs;

public class StaffAssignmentsDTO
{
    public List<StaffDTO> Staffs { get; set; } = new List<StaffDTO>();
    public string Role { get; set; }
}