using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeHelper.Domain;
using TraineeHelper.Persistence;

namespace TraineeHelper.Tests.Common;
public abstract class TestCommandBase : IDisposable
{
    protected readonly LearningSessionsDbContext _context;

    public TestCommandBase()
    {
        _context = LearningSessionsContextFactory.Create();
    }

    public void Dispose()
    {
        LearningSessionsContextFactory.Destroy(_context);
    }
}
