export class Ticket {
    constructor(
        public ticketId: number | null,
        public fullName: string,
        public email : string,
        public statuId : number | null,
        public description: string,
        public summary: string | null,
        public imageUrl: string | null,
        public solution: string | null
    ){}
}