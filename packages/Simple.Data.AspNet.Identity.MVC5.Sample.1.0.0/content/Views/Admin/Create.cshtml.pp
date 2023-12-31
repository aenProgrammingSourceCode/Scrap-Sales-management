@model $rootnamespace$.Models.UserViewModel

@{
    ViewBag.Title = "Create";
}

<h2>Create</h2>

@using (Html.BeginForm())
{
    @Html.ValidationSummary(true)
    <fieldset>
        <legend>UserProfile</legend>

        @Html.Partial("_CreateOrEdit", Model)

        <p>
            <input type="submit" value="Create" class="btn btn-default" />
        </p>
    </fieldset>
}

<div>
    @Html.ActionLink("Back to List", "Index")
</div>


