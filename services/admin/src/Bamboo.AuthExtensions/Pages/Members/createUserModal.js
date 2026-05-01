var abp = abp || {};

abp.modals.createUserModal = function () {
  var initModal = function (publicApi, args) {
    console.log("createUserModal initialized");

    var $tenantIdSelect = $("#User_TenantId");
    var $roleNameSelect = $("#User_RoleName");

    // Khi thay đổi tenant, load roles
    $tenantIdSelect.on("change", function () {
      var tenantId = $(this).val();

      $roleNameSelect.empty().append(new Option("...", ""));

      abp.ajax({
        url:
          "/Members/CreateUserModal?handler=Roles&tenantId=" + (tenantId || ""),
        type: "GET",
        dataType: "json",
        success: function (roles) {
          roles.forEach(function (role) {
            $roleNameSelect.append(new Option(role.text, role.value));
          });
        },
      });
    });

    $tenantIdSelect.trigger("change"); // load roles mặc định

    // Optional: bind submit success
    var form = $("#createUserForm");
    form.on("submit", function () {
      console.log("createUserForm submitted via ABP AJAX");
    });
  };

  return {
    initModal: initModal,
  };
};
