namespace Student.Command.Domain.Commands
{
    public interface IUpdateStudentCommand
    {
        Guid Id { get; }
        string Name { get; }
        string Phone { get; }
        string Address { get; }
        Guid UserId { get; }
    }
}
