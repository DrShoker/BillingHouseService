import React, { Component, Fragment } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import {
  Router, Route, Switch, Redirect,
} from 'react-router-dom';
import history from './utils/history';
import DocumentTitle from 'react-document-title';
import { applicationTitle } from './utils/applicationTitle';
import { signinRequest } from './pages/login/actions/loginActions';
import  LoginPage  from './pages/login/login-page';
import TopBar from './common/components/appBar/appBar';
import SidebarComponent from './common/components/sideBar/sideBar';
import ProfilePage from './pages/profile/profile-page';

import './App.css';

class AppRoute extends Component {

  // componentDidMount() {
  //   const {
  //     signinRequest
  //   } = this.props;

  //   signinRequest({email: 'shokergood@gmail.com', password: '060198'})
  //   console.log("WTF");
  // }

  render() {
    const {
      userId,
    } = this.props;
    const rights = userId ? true : false;

    return (
      <DocumentTitle title={applicationTitle.getTitile('bh')}>
        <Router history={history}>
          <div className='app'>
            <TopBar />
            <SidebarComponent />
            {rights ? (
              <Switch>
                {/* <Route exact path="/" component={MapPage} /> */}
                <Route path="/login" component={LoginPage} />
                <Route path="/profile" component={ProfilePage} />
                {/* <Route path="/email-registration" component={EmailRegistrationPage} /> */}
                {/* <Route path="/finish-registration" component={FinishRegistrationPage} /> */}
                {/* <Route path="/refresh-password" component={RefreshPasswordPage} /> */}
                {/* <Route path="/forgot-password" component={ForgotPasswordPage} /> */}
                {/* <Route path="/profile" component={Profile} /> */}
              </Switch>
            ) : (
              <Switch>
                <Route exact path='/login' component={LoginPage} />
                <Redirect to='/login' />
              </Switch>
            )}
          </div>
        </Router>
      </DocumentTitle>
    )
  }
}

AppRoute.propTypes = {
  authToken: PropTypes.string,
};

export default connect(store => ({
  authToken: store.authReducer.authToken,
  userId: store.authReducer.id
}),
{
  signinRequest,
  // logout,
  // setRoles,
  // getVersion,
  // closeDialog,
  // confirmDeleteDialog,
  // closeAlertDialog,
})(AppRoute);