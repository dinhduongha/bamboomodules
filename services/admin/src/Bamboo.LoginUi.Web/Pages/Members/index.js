﻿﻿abp.log.level = abp.log.levels.debug;
abp.log.debug("Debug mode ON for modal");
$(function () {
  // --- MODAL MANAGERS ---
  var createTenantModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/CreateTenantModal",
    formId: "createTenantForm",
  });
  $("#CreateTenantButton").on("click", function (e) {
    e.preventDefault();
    abp.log.debug("Debug CreateTenantModal click");
    createTenantModal.open();
  });
  createTenantModal.onResult(function () {
    abp.log.debug("Debug CreateTenantModal onResult");
    location.reload();
  });

  var createUserModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/CreateUserModal",
    formId: "createUserForm",
  });

  var inviteModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/InviteMemberModal",
    formId: "inviteMemberForm",
  });

  var createMemberModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/CreateMemberModal",
    formId: "createMemberForm",
  });

  var editMember = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/EditMemberModal",
    formId: "editMemberForm",
  });

  // --- CLICK HANDLERS ---
  $("#InviteMemberButton").on("click", function (e) {
    e.preventDefault();
    inviteModal.open();
  });

  $("#CreateMemberButton").on("click", function (e) {
    e.preventDefault();
    createMemberModal.open();
  });

  $("#CreateUserButton").on("click", function (e) {
    e.preventDefault();
    createUserModal.open();
  });

  $(document).on("click", ".edit-member-button", function (e) {
    e.preventDefault();
    var id = $(this).data("id");
    editMember.open({ id: id });
  });

  // --- ON RESULT (RELOAD PAGE) ---
  inviteModal.onResult(function () {
    location.reload();
  });

  createMemberModal.onResult(function () {
    location.reload();
  });

  createUserModal.onResult(function () {
    location.reload();
  });

  editMember.onResult(function () {
    location.reload();
  });
});
