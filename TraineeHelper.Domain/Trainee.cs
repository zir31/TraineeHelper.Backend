using System;

namespace TraineeHelper.Domain
{
    public class Trainee
    {
        Guid Id { get; set; }
        string FullName { get; set; }
        IEnumerable<string> Skills { get; set; }
    }
}
