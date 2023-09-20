namespace CubosBankAPI.Application.DTOs.ResponseDTO
{
    public class PersonDTOResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public PersonDTOResponse(
            Guid id, string name, string document, DateTime createdAt, DateTime updatedAt
            )
        {
            Id = id;
            Name = name;
            Document = document;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

    }
}