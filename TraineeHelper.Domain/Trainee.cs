using System;

namespace TraineeHelper.Domain
{
    public class Trainee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public IEnumerable<string> Skills { get; set; }
    }
}
