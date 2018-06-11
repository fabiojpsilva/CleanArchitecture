using System;

namespace CleanDemo.Core
{
    public interface IInteraction<in TInput, out TOutput>
    {
        TOutput Handle(TInput input);
    }
}
