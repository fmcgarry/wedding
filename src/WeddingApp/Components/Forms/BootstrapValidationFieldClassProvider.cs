using Microsoft.AspNetCore.Components.Forms;

namespace WeddingApp.Components.Forms;

public class BootstrapValidationFieldClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        bool isValid = editContext.IsValid(fieldIdentifier);
        bool isModified = editContext.IsModified(fieldIdentifier);

        // Set true case for isValid to "valid" (blazor) or "is-valid" (bootstrap) to get green borders
        return $"{(isModified ? "modified " : "")}{(isValid ? "" : "is-invalid")}";
    }
}
