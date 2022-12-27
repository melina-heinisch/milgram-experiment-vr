using System.Collections;
using System.Collections.Generic;

public interface IInstruction 
{
    public bool isDone();
    public void OnStartOfInstruction(ReferenceAssociationCanvas canvasReferences, ContentAssociationspaar assoziation);
}
