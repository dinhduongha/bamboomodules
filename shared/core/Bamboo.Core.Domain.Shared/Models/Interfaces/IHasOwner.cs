using System;
using System.Collections.Generic;

public interface IHasOwner
{
    public Guid? UserId { get; set; }
}