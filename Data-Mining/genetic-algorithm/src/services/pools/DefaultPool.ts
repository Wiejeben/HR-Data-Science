import AbstractPool from "./AbstractPool";
import DNA from "../DNA";
import Population from "../Population";

export default class DefaultPool extends AbstractPool {
    private matingPool: DNA[] = [];

    constructor(population: Population) {
        super(population);
    }

    public naturalSelection(): void {
        this.matingPool = [];
        const population = this.population.getPopulation();

        const max = this.population.best();

        for (const dna of population) {
            const n = (dna.fitness / max.fitness) * 100;
            for (let j = 0; j < n; j++) {
                this.matingPool.push(dna);
            }
        }
    }

    public generate(): DNA[] {
        const newPopulation = [];

        if (this.matingPool.length === 0) {
            throw Error('Mating pool not yet generated');
        }

        for (let i = 0; i < this.population.getPopulation().length; i++) {
            const left = this.matingPool[Math.floor(this.randomNumber(0, this.matingPool.length - 1))];
            const right = this.matingPool[Math.floor(this.randomNumber(0, this.matingPool.length - 1))];

            const child = left.crossover(right);
            child.mutate(this.population.getMutationRate());

            // Overwrite existing population
            newPopulation[i] = child;
        }

        return newPopulation;
    }

    private randomNumber(min: number, max: number): number {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
}