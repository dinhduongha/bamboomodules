(function () {
  $(document).on("abp.modal.init", ".create-tenant-modal", function () {
    console.log("Modal initialized");

    $("#createTenantForm").on("submit", function (e) {
      console.log("createTenantForm Submit fired");
    });
  });
})();
