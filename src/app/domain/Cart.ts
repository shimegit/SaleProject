import { Gift } from "./Gifts";

export interface Cart {

  userId?: number;
  giftId?: number;
  quantity?: number;
  gift?: Gift;



}
export const DEFAULT_QUANTITY = 1;