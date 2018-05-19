import AbstractPool from "./AbstractPool";
import DNA from "../DNA";
import Population from "../Population";

/**
 * Unreliable, probably have to tweak my fitness value for this: https://github.com/CodingTrain/Rainbow-Topics/issues/119
 */
export default class RouletteWheelPool extends AbstractPool {
    public matingPool: Array<[DNA, number]>;

    constructor(population: Population) {
        super(population);
    }

    /**
     * Compute weights using a tuple.
     */
    public naturalSelection(): void {
        const sum: number = this.population.getPopulation()
            .map<number>(dna => dna.fitness)
            .reduce((total, current) => total + current, 0);

        this.matingPool = this.population.getPopulation()
            .map<[DNA, number]>((dna) => [dna, dna.fitness / sum]);
    }

    /**
     * Select random item based on weight or throw an exception if we failed.
     *
     * @return {DNA}
     */
    public select(): DNA {
        let random = Math.random();
        for (const value of this.matingPool) {
            const [dna, weight] = value;
            if (random < weight) {
                return dna;
            } else {
                random -= weight
            }
        }

        throw Error('Failed to select a random item. Make sure you ran the natural selection beforehand.');
    }
}