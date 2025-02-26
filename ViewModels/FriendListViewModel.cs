﻿using Common.Base;
using Common.Extensions;
using CommunityToolkit.Mvvm.Input;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ViewModels;

public class FriendListViewModel : ViewModelBase
{
    private readonly IUserService _userService;

    private ICollectionView _friendListView;
    private User _myProfile;
    private ObservableCollection<User> _friendList;

    public FriendListViewModel(IUserService userService)
    {
        _userService = userService;

        MyProfile = _userService.UserInfo;

        FriendList = new ObservableCollection<User>(_userService.UserInfo.FriendList);
        FriendListView = CollectionViewSource.GetDefaultView(FriendList);

        PropertyGroupDescription groupDescription = new PropertyGroupDescription("FriendUserType");
        FriendListView.GroupDescriptions.Add(groupDescription);
        FriendListView = CollectionViewSource.GetDefaultView(FriendList);
    }

    #region Properties
    public User MyProfile
    {
        get => _myProfile;
        set => SetProperty(ref _myProfile, value);
    }

    public ObservableCollection<User> FriendList
    {
        get => _friendList;
        set => SetProperty(ref _friendList, value);
    }

    public ICollectionView FriendListView
    {
        get => _friendListView;
        set => SetProperty(ref _friendListView, value);
    }
    #endregion  // Properties

    #region Commands
    private RelayCommand<User?> _profileCommand;
    public RelayCommand<User?> ProfileCommand
    {
        get
        {
            return _profileCommand ??
                (_profileCommand = new RelayCommand<User?>(this.ProfileExecute));
        }
    }

    private RelayCommand<User?> _chatCommand;
    public RelayCommand<User?> ChatCommand
    {
        get
        {
            return _chatCommand ??
                (_chatCommand = new RelayCommand<User?>(this.ChatExecute));
        }
    }
    #endregion  // Commands

    #region Commands Execute Methods
    private void ProfileExecute(User? user)
    {

    }

    private void ChatExecute(User? user)
    {
        //
    }
    #endregion  // Commands Execute Methods

    #region Methods
    //
    #endregion  // Methods
}
