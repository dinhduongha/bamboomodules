var abp = abp || {};

abp.modals.editMember = function () {
  var initModal = function (publicApi, args) {
    // Initialize something if needed
  };

  return {
    initModal: initModal,
  };
};

  var createUserModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/CreateUserModal",
    formId: "createUserForm",
  });

  var inviteModal = new abp.ModalManager({
    viewUrl: abp.appPath + "Members/InviteMemberModal",
    formId: "inviteMemberForm",
  });

  var
