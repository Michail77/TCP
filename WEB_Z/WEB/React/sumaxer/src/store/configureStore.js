import { applyMiddleware, combineReducers, compose, createStore } from 'redux'
import * as Game from './Game'

export default function configureStore (history, initialState) {

    const middleware = [];

    const enhancers = [];

    const rootReducer = () => combineReducers({
        game: Game.reducer
    });

    return createStore(
        rootReducer(history),
        initialState,
        compose(applyMiddleware(...middleware), ...enhancers)
    );
}