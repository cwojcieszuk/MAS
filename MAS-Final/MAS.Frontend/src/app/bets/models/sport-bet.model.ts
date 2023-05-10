export interface SportBetModel {
  idBet: number;
  dateTime: Date;
  idBetSport: number;
  sportname: string;
  team1: string;
  team2: string;
  options: SportBetOption[];
}

export interface SportBetOption {
  idBetSportOption: number;
  odds: number;
  status: string;
  betName: string;
}

export interface SportBetWithOption {
  idBet: number;
  dateTime: Date;
  idBetSport: number;
  sportname: string;
  team1: string;
  team2: string;
  idBetSportOption: number;
  odds: number;
  status: string;
  betName: string;
}
