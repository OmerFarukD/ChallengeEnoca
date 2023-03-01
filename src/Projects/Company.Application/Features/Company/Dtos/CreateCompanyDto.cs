namespace Company.Application.Features.Company.Dtos;

public sealed class CreateCompanyDto
{
    public string? CompanyName { get; set; }
    
    public bool IsActive { get; set; }
    
    public  DateTime DateTimeStart { get; set; }
    
    public  DateTime DateTimeEnd { get; set; }
    
}