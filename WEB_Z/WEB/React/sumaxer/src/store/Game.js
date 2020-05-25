import game from "../model"

const initialState = game.initGame();
console.log(initialState);

const TURN_CARD = "TURN_CARD";

export const actionCreators = {
    turnCard: (card) =>
    {
        return {type: TURN_CARD,payload:card};
    }
};

export const reducer = (state, action) =>
{
    state = state || initialState;
    switch (action.type)
    {
        case TURN_CARD:
        {
            state.Turn(action.payload);
            return new game({...state});
        }
        default :
        {
            return state;
        }
    }
};