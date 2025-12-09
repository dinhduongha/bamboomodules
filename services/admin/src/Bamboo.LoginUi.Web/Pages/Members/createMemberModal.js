var abp = abp || {};

abp.modals.createMemberModal = function () {
  var initModal = function (publicApi, args) {
    console.log("createMemberModal initialized");
    var $tenantIdSelect = $("#Member_TenantId");
    var $rolesSelect = $("#Member_Roles");

    $tenantIdSelect.on("change", function () {
      var selectedTenantId = $(this).val();
      $rolesSelect.empty(); // Xóa các vai trò cũ

      // Gọi handler OnGetRolesAsync ở backend (cần thêm vào CreateMemberModal.cshtml.cs)
      abp.ajax({
        url:
          publicApi.url.replace("CreateMemberModal", "CreateUserModal") +
          "Roles?tenantId=" +
          (selectedTenantId || ""),
        type: "GET",
        dataType: "json",
        success: function (data) {
          data.forEach(function (role) {
            $rolesSelect.append(new Option(role.text, role.value));
          });
        },
      });
    });
  };

  return {
    initModal: initModal,
  };
};
