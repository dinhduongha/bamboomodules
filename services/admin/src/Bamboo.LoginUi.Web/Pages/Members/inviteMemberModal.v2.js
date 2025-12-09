$(function () {
  var l = abp.localization.getResource("Admin"); // Define l here

  console.log("Inline modal script loaded");

  var $modal = $("[data-modal-name='inviteMemberModal']");
  if ($modal.length > 0) {
    console.log("Modal inviteMemberModal found");

    var $tenantSelect = $("#Member_TenantId");
    var $roleSelect = $("#Member_RoleId");

    $tenantSelect.on("change", function () {
      var tenantId = $(this).val();
      $roleSelect.empty().append(new Option("Loading...", ""));
      console.log("Modal inviteMemberModal tenantSelect changed");

      abp.ajax({
        url: "/Members/CreateUserModal?handler=Roles&tenantId=" + tenantId,
        type: "GET",
        dataType: "json",
        success: function (roles) {
          $roleSelect.empty();
          roles.forEach(function (r) {
            $roleSelect.append(new Option(r.text, r.value));
          });
          // Tìm vai trò 'group_user' và lấy Id của nó để đặt làm giá trị mặc định
          var defaultRole = roles.find(function (r) {
            return r.text === "group_user";
          });
          if (defaultRole) {
            $roleSelect.val(defaultRole.value).trigger("change"); // Set default by ID and update Select2
          }
        },
      });
    });

    $tenantSelect.trigger("change");

    $("#inviteMemberForm").on("submit", function () {
      console.log("Form submit triggered");
    });
    // Khởi tạo Select2 cho các trường chọn vai trò
    $(".select2-roles").select2({
      theme: "bootstrap-5", // Sử dụng theme Bootstrap 5 để tích hợp tốt hơn
      dropdownParent: $modal.find(".abp-modal-body"), // Chỉ định chính xác parent là body của modal này
      allowClear: true, // Cho phép xóa lựa chọn
      placeholder: l("SelectRole"), // Sử dụng placeholder đã được localize
    });
  }
});
