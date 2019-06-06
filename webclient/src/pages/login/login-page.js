import * as React from 'react';
import { connect } from 'react-redux';
import TextField from '@material-ui/core/TextField';
import AccountCircle from '@material-ui/icons/AccountCircle';
import VpnKey from '@material-ui/icons/VpnKey';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { signinRequest, signupRequest, resetSuccessor } from './actions/loginActions';
import './login-page.css'

export class LoginPage extends React.Component {

    state = {
        isSingIn: true,
        email: '',
        password: '',
        repeatedPassword: '',
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        const { isRegSucces } = nextProps;
        console.log(isRegSucces);
        if (isRegSucces && !prevState.isSingIn) {
            return { isSingIn: isRegSucces }
        }
        else return null;
    }

    onEmailChange = (newValue) => {
        this.setState({
            email: newValue.target.value
        });
    };

    onPasswordChange = (newValue) => {
        this.setState({
            password: newValue.target.value
        });
    };

    onRepeatedPasswordChange = (newValue) => {
        this.setState({
            repeatedPassword: newValue.target.value
        });
    };

    sendLoginData = () => {
        const { email, password } = this.state;
        const { signinRequest } = this.props;
        console.log(email, password);
        signinRequest({ email, password });
    };

    sendRegisterData = () => {
        const { email, password, repeatedPassword } = this.state;
        const { signupRequest, isRegSucces } = this.props;
        signupRequest({email, password, repeatedPassword});
    }

    goToSignUp = () => {
        this.props.resetSuccessor();
        this.setState({
            isSingIn: !this.state.isSingIn,
        });

    };

    render() {
        const { isSingIn } = this.state;
        return (
            <div className="login-page">
                <div className="login-black-containter">
                    <div className="login-title">
                        <span>Billing House Service</span>
                    </div>
                    {isSingIn ? (
                        <div className="login-white-container">
                            <div className="login-box">
                                <div className="login-box-label">
                                    <span>Sing In</span>
                                </div>
                                <div>
                                    <Grid container spacing={1} alignItems="flex-end">
                                        <Grid item>
                                            <AccountCircle />
                                        </Grid>
                                        <Grid item>
                                            <TextField
                                                id="input-with-icon-grid"
                                                label="Email"
                                                onChange={this.onEmailChange}
                                            />
                                        </Grid>
                                    </Grid>
                                </div>
                                <div>
                                    <Grid container spacing={1} alignItems="flex-end">
                                        <Grid item>
                                            <VpnKey />
                                        </Grid>
                                        <Grid item>
                                            <TextField
                                                id="standard-password-input"
                                                label="Password"
                                                type="password"
                                                autoComplete="current-password"
                                                onChange={this.onPasswordChange}
                                            />
                                        </Grid>
                                    </Grid>
                                </div>
                                <div className="login-buttons">
                                    <Button
                                        className="singIn-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={this.sendLoginData}
                                    >
                                        Sing In
                                </Button>
                                    <Button
                                        className="signUp-button"
                                        size="medium"
                                        variant="contained"
                                        onClick={this.goToSignUp}>
                                        Sign Up
                                </Button>
                                </div>
                            </div>
                        </div>
                    ) : (
                            <div className="register-white-container">
                                <div className="register-box">
                                    <div className="register-box-label">
                                        <span>Sign Up</span>
                                    </div>
                                    <div>
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <AccountCircle />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="input-with-icon-grid"
                                                    label="Email"
                                                    onChange={this.onEmailChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                    <div>
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <VpnKey />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="standard-password-input"
                                                    label="Password"
                                                    type="password"
                                                    autoComplete="current-password"
                                                    onChange={this.onPasswordChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                    <div>
                                        <Grid container spacing={1} alignItems="flex-end">
                                            <Grid item>
                                                <VpnKey />
                                            </Grid>
                                            <Grid item>
                                                <TextField
                                                    id="standard-password-input"
                                                    label="Repeated Password"
                                                    type="password"
                                                    autoComplete="current-password"
                                                    onChange={this.onRepeatedPasswordChange}
                                                />
                                            </Grid>
                                        </Grid>
                                    </div>
                                    <div className="login-buttons">
                                        <Button
                                            className="singIn-button"
                                            size="medium"
                                            variant="contained"
                                            onClick={this.sendRegisterData}
                                        >
                                            Sing Up
                                        </Button>
                                        <Button
                                            className="signUp-button"
                                            size="medium"
                                            variant="contained"
                                            onClick={this.goToSignUp}>
                                            Sign In
                                        </Button>
                                    </div>
                                </div>
                            </div>
                        )
                    }
                </div>
            </div>
        )
    }
}

export default connect(store => ({
    isRegSucces: store.loginReducer.isRegistrationSuccess
}),
    {
        signinRequest,
        signupRequest,
        resetSuccessor
    })(LoginPage);