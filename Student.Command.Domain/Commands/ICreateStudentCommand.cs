namespace Student.Command.Domain.Commands
{
    public interface ICreateStudentCommand
    {
        string Name { get; }
        string Phone { get; }
        string Address { get; }
        Guid UserId { get; }
    }
}
