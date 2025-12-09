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
    viewUrl: "/Members/CreateUserModal",
    formId: "createUserForm",
  });

  // Mở modal khi click button
  $("#CreateUserButton").on("click", function (e) {
    e.preventDefault();
    abp.log.debug("Open CreateUserModal");
    createUserModal.open(); // tự gọi initModal
  });

  // Khi modal submit thành công
  createUserModal.onResult(function () {
    abp.log.debug("CreateUserModal submitted successfully");
    location.reload(); // hoặc cập nhật DOM mà không reload
  });

  var inviteMemberModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/InviteMemberModal",
    formId: "inviteMemberForm",
  });

  var createMemberModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/CreateMemberModal",
    formId: "createMemberForm",
  });

  var editMemberModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/EditMemberModal",
    formId: "editMemberForm",
  });

  // --- CLICK HANDLERS ---
  $("#InviteMemberButton").on("click", function (e) {
    e.preventDefault();
    inviteMemberModal.open();
  });

  $("#CreateMemberButton").on("click", function (e) {
    e.preventDefault();
    createMemberModal.open();
  });

  $(document).on("click", ".edit-member-button", function (e) {
    e.preventDefault();
    var id = $(this).data("id");
    editMemberModal.open({ id: id });
  });

  // --- ON RESULT (RELOAD PAGE) ---
  inviteMemberModal.onResult(function () {
    location.reload();
  });

  createMemberModal.onResult(function () {
    location.reload();
  });

  editMemberModal.onResult(function () {
    location.reload();
  });
});
