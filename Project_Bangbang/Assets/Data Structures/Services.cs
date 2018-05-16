using System;

public struct Services
{
    public IEntityService entity { get; set; }
    public IInputService input { get; set; }
    public IScreenService screen { get; set; }
    public ITimeService time { get; set; }
}

