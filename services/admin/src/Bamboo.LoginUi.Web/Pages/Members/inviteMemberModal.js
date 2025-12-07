(function () {
  $(document).on("abp.modal.init", ".invite-member-modal", function () {
    console.log("Modal initialized");

    $("#createTenantForm").on("submit", function (e) {
      console.log("Submit fired");
    });
  });
})();
