//herní karta s hodnotou na líci a yin-yang na rubu
class boardPiece {
    constructor(value) {        
        this.turned = false;
        this.value = value;
    }

    turn() {
        this.turned = !this.turned;
    }
}

//herní mechanika
class suMaxer {
    constructor(gameData) {
        this.board = gameData.board; //kolekce karet na DESKu
        this.maxTurned = gameData.maxTurned; //maximální počet v jednu chvíli otočených karet
        this.turnsLeft = gameData.turnsLeft; //zbývající počet tahů (otočení lícem vzhůru) do konce hry
        this.selected = gameData.selected; //kolekce hodnot (value) otočených karet
        this.sum = gameData.sum; //aktualizovaný součet hodnot všech otočených karet
    }

    static initGame(maxTurned = 4, maxTurns = 12, noOfCards = 24) {
        const newBoard = [];
        for (let i = 1; i <= noOfCards; i++) newBoard.push(new boardPiece(i));
        suMaxer._shuffleBoard(newBoard);

        let gD = {
            board: newBoard,
            maxTurned: maxTurned,
            turnsLeft: maxTurns,
            selected: [],
            sum: 0
        }

        return new suMaxer(gD);
    }

    static _shuffleBoard(board) {
        for (let i = board.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [board[i], board[j]] = [board[j], board[i]];
        }
    }

    _getTurned() {
        return this.board.filter(bp => bp.turned).length;
    }

    _getSum() {
        return this.board.filter(bp => bp.turned).reduce(
            (acc, bp) => acc + (bp.value || 0), 0
        );
    }

    //number - hodnota na kartě (nikoliv její index!)
    Turn(number) {
        var self = this;
        var positionInSelected = this.selected.indexOf(number);
        if ((this.turnsLeft > 0) && ((this._getTurned() < this.maxTurned) || (positionInSelected !== -1))) {
            this.board.forEach(function(bp) {
                if (bp.value === number) {
                    bp.turn();
                    if (bp.turned) self.turnsLeft--;
                    let positionInSelected = self.selected.indexOf(number);
                    if (positionInSelected !== -1)
                        self.selected.splice(positionInSelected, 1);
                    else
                        self.selected.push(number);
                }
            });
            this.sum = this._getSum();
        }
    }
}
export default suMaxer;