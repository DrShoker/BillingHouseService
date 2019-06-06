import React, { Component, Fragment } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import {
  Router, Route, Switch, Redirect,
} from 'react-router-dom';
import history from './utils/history';
import DocumentTitle from 'react-document-title';
import { applicationTitle } from './utils/applicationTitle';
import {signinRequest} from './pages/login/actions/loginActions'

import './App.css';

class AppRoute extends Component {

  componentDidMount() {
    const {
      signinRequest
    } = this.props;

    signinRequest({email: 'shokergood@gmail.com', password: '060198'})
    console.log("WTF");
  }

  render() {
    const {
      authToken,
      userId
    } = this.props;
    const rights = authToken ? true : false;

    return (
      <DocumentTitle title={applicationTitle.getTitile('bh')}>
        <Router history={history}>
          <div className='app'>
            <div>{userId}</div>
            {rights ? (
              <Switch>
                {/* <Route exact path="/" component={MapPage} />
                <Route path="/login" component={LoginPage} />
                <Route path="/registration" component={RegistrationPage} />
                <Route path="/email-registration" component={EmailRegistrationPage} />
                <Route path="/finish-registration" component={FinishRegistrationPage} />
                <Route path="/refresh-password" component={RefreshPasswordPage} />
                <Route path="/forgot-password" component={ForgotPasswordPage} />
                <Route path="/profile" component={Profile} /> */}
              </Switch>
            ) : (
              <Switch>
                {/* <Route exact path='/login' component={LoginPage} /> */}
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
  userId: store.authReducer.Id
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