$(function () {
  console.log("Inline modal script loaded");

  var $modal = $("[data-modal-name='addMemberModal']");
  if ($modal.length > 0) {
    console.log("Modal addMemberModal found");

    var $tenantSelect = $("#Member_TenantId");
    var $roleSelect = $("#Member_RoleName");

    $tenantSelect.on("change", function () {
      var tenantId = $(this).val();
      $roleSelect.empty().append(new Option("Loading...", ""));
      console.log("Modal addMemberModal tenantSelect changed");

      abp.ajax({
        url: "/Members/CreateUserModal?handler=Roles&tenantId=" + tenantId,
        type: "GET",
        dataType: "json",
        success: function (roles) {
          $roleSelect.empty();
          roles.forEach(function (r) {
            $roleSelect.append(new Option(r.text, r.value));
          });
        },
      });
    });

    $tenantSelect.trigger("change");

    $("#addMemberForm").on("submit", function () {
      console.log("Form submit triggered");
    });
  }
});
