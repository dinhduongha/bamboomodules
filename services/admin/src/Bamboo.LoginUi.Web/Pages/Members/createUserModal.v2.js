$(function () {
  console.log("Inline modal script loaded");

  var $modal = $("[data-modal-name='createUserModal']");
  if ($modal.length > 0) {
    console.log("Modal found");

    var $tenantSelect = $("#User_TenantId");
    var $roleSelect = $("#User_RoleName");

    $tenantSelect.on("change", function () {
      var tenantId = $(this).val();
      $roleSelect.empty().append(new Option("Loading...", ""));

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

    $("#createUserForm").on("submit", function () {
      console.log("Form submit triggered");
    });
  }
});
