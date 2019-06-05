import { createStore, applyMiddleware } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension/logOnlyInProduction';
import createSagaMiddleware from 'redux-saga';
import reducers from './../common/reducers'
import sagas from './../common/sagas';

const sagaMiddleware = createSagaMiddleware();

const composeEnhancers = composeWithDevTools({
  maxAge: 15,
  latency: 1500,
});

export default function configureStore () {
  const store = createStore(
    reducers,
    composeEnhancers(
      applyMiddleware(sagaMiddleware),
    )
  );
  sagaMiddleware.run(sagas);
  
  return store;
}