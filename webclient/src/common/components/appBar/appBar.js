import * as React from 'react';
import classNames from 'classnames';
import AccountCircle from '@material-ui/icons/AccountCircle';

import './appBar.css'

export class TopBar extends React.Component {
    
    state = {
        isUserMenuExpanded: false,

    };

    expandUserMenu = () => {
        const { isUserMenuExpanded } = this.state;
        this.setState({
          isUserMenuExpanded: !isUserMenuExpanded,
        });
      }

    render() {
        const { isUserMenuExpanded } = this.state;
        return (
            <div className='header-cont'>
            <div className='main-part'>
              {/* {<Alert
                stack={{ limit: 1 }}
                contentTemplate={CustomMessage}
              />}
              {isNotificationOpen ? (
                <Notification
                  onClose={this.toogleNotification}
                  items={allNotifications}
                  clear={this.clearNotifications}
                  deleteItem={this.deleteNotify}
                  getInfoForNotification={this.getInfoForNotification}
                />
              ) : null} */}
              <div className='main-part-item'>
                <div className='notifications' onClick={this.toogleNotification}>
                  {/* {allNotifications.length ? (
                    <CustomIcon iconName='bell_with_notification' />
                  ) : (
                    <CustomIcon iconName='bell_without_notification' />
                  )} */}
                </div>
              </div>
            </div>
            <div
              className='user-menu-container'
              onMouseLeave={this.collapseUserMenu}
              onClick={this.expandUserMenu}
            >
              <div className='user-photo'>
                <AccountCircle fontSize="large"/>
              </div>
              <div className='user-name'>
                <span> User Name </span>
              </div>
              <div className={classNames('user-menu-expander', { 'expanded__user-menu__expander': isUserMenuExpanded })}>
                <svg width='12' height='5' viewBox='0 0 12 5' fill='none' xmlns='http://www.w3.org/2000/svg'>
                  <path d='M0 0L5.97518 5L11.9504 0H0Z' fill='#4B4B4B' />
                </svg>
              </div>
              <div className={classNames('user-menu', { 'expanded-user-menu': isUserMenuExpanded })}>
                {/* <div className='user-menu-option'> // TODO-TDLT-482: uncomment me when design of My Account and Settings page will be done
                  <span>My Account</span>
                </div>
                <div className='user-menu-option'>
                  <span>Settings</span>
                </div> */}
                <div className='user-menu-option'>
                  <span>Log out</span>
                </div>
              </div>
            </div>
          </div>
        );
    }
}

export default TopBar;