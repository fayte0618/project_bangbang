using System;

public interface ITimeService
{
    float Delta { get; }
    float UnscaledDelta { get; }
    float FixedDelta { get; }
    float FixedUnscaledDelta { get; }
}

