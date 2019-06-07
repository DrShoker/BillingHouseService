import * as React from 'react';
import classNames from 'classnames';
//import CustomIcon from '../icon/Icon';
import AccountCircle from '@material-ui/icons/AccountCircle';
import Home from '@material-ui/icons/Home';
import List from '@material-ui/icons/List';
import CardTravel from '@material-ui/icons/CardTravel';
import Build from '@material-ui/icons/Build';
import FormatPaint from '@material-ui/icons/FormatPaint';
import Forum from '@material-ui/icons/Forum';
import LiveHelp from '@material-ui/icons/LiveHelp';
import history from './../../../utils/history';
import { Link } from 'react-router-dom';
import './sideBar.css';

class SidebarComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isSidebarExpanded: true,
      pathname: window.location.pathname,
      locationName: '',
    };

    this.collapseSidebar = this.collapseSidebar.bind(this);
    history.listen(this.listenHistory);
  }

  collapseSidebar = () => {
    const { isSidebarExpanded } = this.state;
    this.setState({ isSidebarExpanded: !isSidebarExpanded });
  }

  listenHistory = (location) => {
    this.setState({
      pathname: location.pathname,
    });
  }

  refreshHistoryState = () => {
    if (typeof history.location.state === 'undefined') {
      history.location.state = { filters: {}, search: '' };
    } else {
      if (history.location.state && history.location.state.filters && history.location.state.search) {
        history.location.state = { filters: {}, search: '' };
      }
    }
  }

  refreshHistorySearch = () => {
    if (typeof history.location.state === 'undefined') {
      history.location.state = { search: '' };
    } else {
      if (history.location.state && history.location.state.filters && history.location.state.search) {
        history.location.state = { search: '' };
      }
    }
  }

  render() {
    const { version, admin } = this.props;
    const { isSidebarExpanded, pathname } = this.state;
    return (
      <div className={isSidebarExpanded ? 'sidebar-cont expanded' : 'sidebar-cont collapsed'}>
        <div className='sidebar-container'>
          <div className='sidebar-row'>
            <div className='sidebar-row-svg' onClick={this.collapseSidebar}>
              <List className='sidebar-menu' />
            </div>
            <div className={isSidebarExpanded ? 'logo text-expanded' : 'logo text-collapsed'}>
              <Home iconName='sidebar-logo'/>
                <span>Billing House</span>
            </div>
          </div>
          <Link to='/profile'>
            <div
              className={classNames('sidebar-row sidebar-option', {
                'selected-tab': pathname.includes('/profile'),
              })}
            >
              <div className='sidebar-row-svg'>
                <AccountCircle iconName='sidebar-dashboard' />
              </div>
              <div className={isSidebarExpanded ? 'sidebar-row-text text-expanded' : 'sidebar-row-text text-collapsed'}>
                <span>Profile</span>
              </div>
            </div>
          </Link>
          <Link
            to={{
              pathname: '/companies',
              state: {
                search: '',
              },
            }}
          >
            <div
              className={classNames('sidebar-row sidebar-option', {
                'selected-tab': pathname.includes('/companies'),
              })}
              onClick={this.refreshHistorySearch}
            >
              <div className='sidebar-row-svg'>
                <CardTravel iconName='sidebar-offices' />
              </div>
              <div className={isSidebarExpanded ? 'sidebar-row-text text-expanded' : 'sidebar-row-text text-collapsed'}>
                <span>Companies</span>
              </div>
            </div>
          </Link>
          <Link
            to={{
              pathname: '/works',
              state: {
                filters: {},
                search: '',
              },
            }}
          >
            <div
              className={classNames('sidebar-row sidebar-option', {
                'selected-tab': pathname.includes('/works'),
              })}
              onClick={this.refreshHistoryState}
            >
              <div className='sidebar-row-svg'>
                <Build iconName='sidebar-employees' />
              </div>
              <div className={isSidebarExpanded ? 'sidebar-row-text text-expanded' : 'sidebar-row-text text-collapsed'}>
                <span>Works</span>
              </div>
            </div>
          </Link>
          <Link
            to={{
              pathname: '/materials',
              state: {
                search: '',
              },
            }}
          >
            <div
              className={classNames('sidebar-row sidebar-option', {
                'selected-tab': pathname.includes('/materials'),
              })}
              onClick={this.refreshHistorySearch}
            >
              <div className='sidebar-row-svg'>
                <FormatPaint iconName='sidebar-clients' />
              </div>
              <div className={isSidebarExpanded ? 'sidebar-row-text text-expanded' : 'sidebar-row-text text-collapsed'}>
                <span>Materials</span>
              </div>
            </div>
          </Link>
          <Link
            to={{
              pathname: '/feedbacks',
              state: {
                filters: {},
                search: '',
              },
            }}
          >
            <div
              className={classNames('sidebar-row sidebar-option', {
                'selected-tab': pathname.includes('/feedbacks'),
              })}
              onClick={this.refreshHistoryState}
            >
              <div className='sidebar-row-svg'>
                <Forum iconName='sidebar-projects' />
              </div>
              <div className={isSidebarExpanded ? 'sidebar-row-text text-expanded' : 'sidebar-row-text text-collapsed'}>
                <span>Feedbacks</span>
              </div>
            </div>
          </Link>
          <Link
            to={{
              pathname: '/faq',
              state: {
                filters: {},
                search: '',
              },
            }}
          >
            <div
              className={classNames('sidebar-row sidebar-option', {
                'selected-tab': pathname.includes('/faq'),
              })}
              onClick={this.refreshHistoryState}
            >
              <div className='sidebar-row-svg'>
                <LiveHelp iconName='sidebar-po' />
              </div>
              <div className={isSidebarExpanded ? 'sidebar-row-text text-expanded' : 'sidebar-row-text text-collapsed'}>
                <span>FAQ</span>
              </div>
            </div>
          </Link>
        </div>
      </div>
    );
  }
}


export default SidebarComponent;