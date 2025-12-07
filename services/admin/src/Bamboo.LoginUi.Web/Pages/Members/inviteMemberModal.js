(function () {
  $(document).on("abp.modal.init", ".invite-member-modal", function () {
    console.log("Modal initialized");

    $("#inviteMemberForm").on("submit", function (e) {
      console.log("Submit fired");
    });
  });
})();
