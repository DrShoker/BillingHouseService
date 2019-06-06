import axios from 'axios';
import qs from 'qs';
import history from './../utils/history';
import config from '../config';

const apiRoot = `${config.host}`;

/* ----------------------------------TO DO--------------------------------------
 /////////////////////////////////////////////////////////////////////////////////
 //   need to create instance with global config for 'header' and 'baseURL'.
 //   need implements axios concurrency for multiple requests.
 //   need to get correct error from back-end and process it in axios interceptor.
 *////////////////////////////////////////////////////////////////////////////////

let updateTokenRequest = null;

export default function http({ method, url, data, params, handleToken }) {
  const token = handleToken ? handleToken : localStorage.getItem('AuthToken');
  let config = {
    method: method.toLowerCase(),
    url: apiRoot + url,
    params,
    paramsSerializer: function (p) {
      return qs.stringify(p, { arrayFormat: 'repeat' });
    },
  };
  if (data) config['data'] = data;

  if (token) config['headers'] = {
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
    'Authorization': "Bearer " + token
  };

  axios.interceptors.response.use(response => {
    return response;
  }, error => {
    if (error.response.status === 401 && error.config && !error.config.__isRetryRequest) {
      return refresh()
        .then((res) => {
          localStorage.setItem('AuthToken', res.data.AuthToken);
          localStorage.setItem('RefreshToken', res.data.RefreshToken);
          return res;
        })
        .then(() => {
          return reRequest(error.config);
        })
        .catch(() => {
          updateTokenRequest = null;
          history.push('/login');
        });
    }
    return error;
  });

  return axios(config);
}
const refresh = () => {
  if (updateTokenRequest) {
    return updateTokenRequest;
  }
  updateTokenRequest = axios({
    url: apiRoot + `auth/refresh-token?=${localStorage.getItem('RefreshToken')}`,
    method: 'get',
    timeout: 10000,
  });
  return updateTokenRequest;
};

const reRequest = (request) => {
  const handleToken = localStorage.getItem('AuthToken');
  let config = {
    url: request.url.replace(apiRoot, ''),
    method: request.method,
    handleToken: handleToken,
  };
  if (request.data) config['data'] = request.data;
  if (request.params) config['params'] = request.params;
  return http(config).then((res) => {
    updateTokenRequest = null;
    return res;
  })
  .catch((err) => {
    return err;
  });
};
