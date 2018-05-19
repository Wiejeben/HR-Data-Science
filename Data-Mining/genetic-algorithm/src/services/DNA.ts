export default class DNA {
    public genes: string[] = [];
    public fitness: number = 0;

    constructor(length: number) {
        for (let i = 0; i < length; i++) {
            this.genes[i] = this.randomChar();
        }
    }

    public toString(): string {
        return this.genes.join('');
    }

    public calcFitness(target: string): void {
        let score = 0;
        for (let i = 0; i < this.genes.length; i++) {
            if (this.genes[i] === target.charAt(i)) {
                score++;
            }
        }

        this.fitness = score / target.length;
    }

    /**
     * Mix two DNA objects.
     *
     * @param {DNA} partner
     * @return {DNA}
     */
    public crossover(partner: DNA): DNA {
        const child = new DNA(this.genes.length);

        const midpoint = Math.floor(this.randomNumber(0, this.genes.length));

        // Half from one, half from the other
        for (let i = 0; i < this.genes.length; i++) {
            if (i > midpoint) {
                child.genes[i] = this.genes[i];
            } else {
                child.genes[i] = partner.genes[i];
            }
        }

        return child;
    }

    public mutate(rate: number): void {
        for (let i = 0; i < this.genes.length; i++) {
            if (Math.random() < rate) {
                this.genes[i] = this.randomChar();
            }
        }
    }

    private randomChar(): string {
        let c = this.randomNumber(63, 122);
        if (c === 63) {
            c = 32;
        }
        if (c === 64) {
            c = 46;
        }

        return String.fromCharCode(c);
    }

    private randomNumber(min: number, max: number): number {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
}